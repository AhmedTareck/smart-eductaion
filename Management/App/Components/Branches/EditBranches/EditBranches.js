export default {
    name: 'EditBranches',    
    created() {
       
        var branch = this.$parent.branchEditObject;
        this.ruleForm.Name = branch.name;
        this.ruleForm.BranchId = branch.branchId;
        this.ruleForm.Description = branch.description;
       
    },
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            form: {
                Name: '',
                Description: '' , 
                BranchId: ''  
            },  
            ruleForm: {
                Name: '',
                Description: ''
            },
            rules: {
                Name: [
                    { required: true, message: 'الرجاء ادخال بيانات الإدارة', trigger: 'blur' },
                    { min: 3, max: 100, message: 'يجب ان يكون الطول مابين 3 الي 25 حرف علي الأقل', trigger: 'blur' }
                ],
                Description: [
                    { required: true, message: 'الرجاء ادخال معلومات عن الإدارة', trigger: 'blur' },
                    { min: 3, max: 450, message: 'يجب ان يكون الطول مابين 3 الي 25 حرف علي الأقل', trigger: 'blur' }
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
                    this.form.BranchLevel = this.$parent.permissionModale;
                    this.$blockUI.Start();
                    this.$http.EditBranches(this.ruleForm)
                        .then(response => {
                            this.$blockUI.Stop();
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
                            this.$blockUI.Stop();
                            this.$message({
                                type: 'error',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + err.response.data + '</strong>'
                            });
                            if (err.response.status === 401) {
                                window.location.href = '/Security/Login';
                            }

                        }


                    );    
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },


    }    
}
