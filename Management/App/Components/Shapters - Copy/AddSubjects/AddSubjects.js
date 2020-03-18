import moment from 'moment';
export default {
    name: 'AddSubjects',

    created() {
        this.form.id = this.$parent.yearSelected;
    },
    components: {
    },
    data() {
        return {
            form: {
                id: '',
                name: '',
            },
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {
        back() {
            this.$parent.state = 0;
        },


        addSubject() {
            this.$http.addSubject(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.GetSubjectInfo();
                    this.$parent.state = 0;
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        }
    }
}
