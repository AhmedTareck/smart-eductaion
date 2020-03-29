import moment from 'moment';
export default {
    name: 'AddPermissions',

    created() {
        //this.form = this.$parent.selectedStudent;
    },
    components: {
    },
    data() {
        return {
            form: {
                id: 0,
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


        addPermissionName() {
            this.$http.addPermissionName(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.GetPermissionsInfo();
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
