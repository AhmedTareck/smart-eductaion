export default {
    name: 'AddNotificationParent',
    created() {

        this.getUserName();


        this.type = [
            {
                id: 1,
                name: "واجب دراسي"
            }, {
                id: 2,
                name: 'إختبار'
            }, {
                id: 3,
                name: "رسالة "
            }, {
                id: 4,
                name: "تنبيه "
            }, {
                id: 5,
                name: "تعميم "
            }


        ];

    },

    data() {

        return {

            type: [],

            ruleForm: {
                notifecation: '',
                type: '',
                userId:'',

            },

            UserName: [],


        };


    },
    methods: {

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.AddUserNotifi(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        AddUserNotifi(formName) {

            this.$http.AddUserNotifi(this.ruleForm)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
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

        },

        getUserName() {
            this.$blockUI.Start();

            this.$http.getUserName(2)
                .then(response => {
                    this.$blockUI.Stop();
                    this.UserName = response.data.names;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                });
        }



    }
}
