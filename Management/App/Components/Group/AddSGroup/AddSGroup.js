import moment from 'moment';
export default {
    name: 'AddGroup',

    created() {
        //this.form.id = this.$parent.yearSelected;
        this.getpermission();
    },
    components: {
    },
    data() {
        return {
          
               
            
            permission: [],

            form: {
                id:[],
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

        getpermission() {

            this.$blockUI.Start();
            this.$http.GetPermissions()
                .then(response => {

                    this.$blockUI.Stop();
                    
                    this.permission = response.data.permission;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        submitForm() {
            this.$refs['form'].validate((valid) => {
                if (valid) {
                    this.addGroup();
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },


        addGroup() {
      

            this.$http.addGroup(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    //this.$parent.GetSubjectInfo();
                    this.$parent.state = 0;
                    this.resetForm(formName);
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
