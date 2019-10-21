export default {
    name: 'AddBranches',    
    created() {
        this.form.BranchLevel=this.$parent.permissionModale;
    },
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,

            ruleForm: {
                Name: '',
                Description: '',
                BranchLevel: 0
            },
            rules: {
                Name: [
                    { required: true, message: 'الرجاء ادخال بيانات الإدارة', trigger: 'blur' },
                    { min: 3, max: 25, message: 'يجب ان يكون الطول مابين 3 الي 25 حرف علي الأقل', trigger: 'blur' }
                ],
                Description: [
                    { required: true, message: 'الرجاء ادخال معلومات عن الإدارة', trigger: 'blur' },
                    { min: 3, max: 25, message: 'يجب ان يكون الطول مابين 3 الي 25 حرف علي الأقل', trigger: 'blur' }
                ]
            }
        };
    },
    methods: {
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.ruleForm.BranchLevel = this.$parent.permissionModale;
                    this.$http.AddBranches(this.ruleForm)
                        .then(response => {
                            this.$parent.state = 0;
                            this.$parent.GetBranches(this.pageNo);
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
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        Back() {
            this.$parent.state = 0;
        },  
    }    
}
