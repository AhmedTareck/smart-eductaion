export default {
    name: 'EditMessageType',    
    created() {
       
        this.ruleForm.Name = this.$parent.EditMessageTypeObj.name;
        console.log(this.$parent.EditMessageTypeObj.description);
        this.ruleForm.Description = this.$parent.EditMessageTypeObj.description;
        this.ruleForm.MessageTypeId = this.$parent.EditMessageTypeObj.messageTypeId;
       
    },
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            ruleForm: {
                Name: '',
                Description: '',
                MessageTypeId:''
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
                    this.$http.EditMessageType(this.ruleForm)
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
                            if (err.response.status === 401) {
                                window.location.href = '/Security/Login';
                            }
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },


    }    
}
