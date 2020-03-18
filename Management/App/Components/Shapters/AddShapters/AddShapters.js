import moment from 'moment';
export default {
    name: 'AddShapters',

    created() {
        this.form.id = this.$parent.yearSelected;
        this.form.SubjectId = this.$parent.SubjectSelected;
    },
    components: {
    },
    data() {
        return {
            form: {
                id: '',
                name: '',
                SubjectId: '',
                ShapterNumber: '',
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
            this.$http.addShapter(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.getShpater();
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
