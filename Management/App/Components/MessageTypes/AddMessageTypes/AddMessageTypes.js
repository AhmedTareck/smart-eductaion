export default {
    name: 'AddMessageType',    
    created() {
       
    },
    data() {
        return {
        
            ruleForm: {
                Name: '',
                Description: '',
            },
            rules: {
                Name: [
                    { required: true, message: 'الرجاء ادخال  نوع الرسالة', trigger: 'blur' },
                    { min: 3, max: 100, message: 'يجب ان يكون الطول مابين 3 الي 100 حرف علي الأقل', trigger: 'blur' }
                ],
                Description: [
                    { required: true, message: 'الرجاء ادخال معلومات عن نوع الرسالة', trigger: 'blur' },
                    { min: 3, max: 450, message: 'يجب ان يكون الطول مابين 3 الي 450 حرف علي الأقل', trigger: 'blur' }
                ]
            }
          
         
        };
    },
    methods: {
        Back() {
            this.$parent.state = 0;
        },

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.$http.AddMessageType(this.ruleForm)
                        .then(response => {
                            this.$parent.state = 0;
                            this.$parent.GetMessageTypes(this.pageNo);
                            this.$message({
                                type: 'success',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + response.data + '</strong>'
                            });
                        })
                        .catch((err) => {
                            this.$message({
                                type: 'error',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + err.response.data + '</strong>'
                            });
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        }


        //Save() {
        //    this.$http.AddAdTypes(this.form)
        //        .then(response => {
        //            this.$parent.state = 0;
        //            this.$parent.GetAdTypes(this.pageNo);
        //            this.$message({
        //                type: 'info',
        //                message: response.data
        //            });
        //        })
        //        .catch((err) => {
        //            this.$message({
        //                type: 'error',
        //                message: err.response.data
        //            });
        //        });
        //},


    }    
}
