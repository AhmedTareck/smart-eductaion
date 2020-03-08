export default {
    name: 'AddNotification',    
    created() 
    {
        this.type = [
            {
                id: 1,
                name: "واجب دراسي"
            },{
                id: 2,
                name: 'إختبار'
            },{
                id: 3,
                name: "رسالة "
            },{
                id: 4,
                name: "تنبيه "
            },{
                id: 5,
                name: "تعميم "
            }


        ];
     
    },
    
    data() {

        return {

            type:[],

            ruleForm: {
                notifecation:'',
                type: '',
             
            },      
       

        };


    },
    methods: {
        
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.AddHomeWorck(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        AddHomeWorck(formName) {

            this.$http.AddNotifi(this.ruleForm)
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



    }    
}
