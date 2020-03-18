import moment from 'moment';
export default {
    name: 'EditShapters',
    
    created() {
        this.form = this.$parent.selectedItem;
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


        editShpter() {
            this.$http.editShpter(this.form)
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
