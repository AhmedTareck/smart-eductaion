export default {
    name: 'AddAdsInfo',    
    created() 
    {
        this.type = [
            {
                id: 1,
                name: "عام"
            },{
                id: 2,
                name: 'خاص بطلبة المركز'
            },


        ];
     
    },
    
    data() {

        return {

            type: [],

            photo: [],

            ruleForm: {
                post:'',
                status: '',
                subject: '',
             
            },      
       

        };


    },
    methods: {
        
        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.UploadImage(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        FileChanged(e) {
            var files = e.target.files;

            if (files.length <= 0) {
                return;
            }

            if (files[0].type !== 'image/jpeg' && files[0].type !== 'image/png') {
                this.$message({
                    type: 'error',
                    message: 'عفوا يجب انت تكون الصورة من نوع JPG ,PNG'
                });
                this.photo = null;
                return;
            }

            var $this = this;

            var reader = new FileReader();
            reader.onload = function () {
                $this.photo = reader.result;
                //$this.UploadImage();
            };
            reader.onerror = function (error) {
                $this.photo = null;
            };
            reader.readAsDataURL(files[0]);
        },



        UploadImage(formName) {
            this.$blockUI.Start();
            var obj = {
                Photo: this.photo,
                post: this.ruleForm.post,
                status: this.ruleForm.status,
                subject: this.ruleForm.subject,
            };
            this.$http.addPost(obj)
                .then(response => {
                    this.$blockUI.Stop();
                    this.resetForm(formName);
                    this.$message({
                        type: 'success',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + response.data + '</strong>'
                    });
                    //setTimeout(() =>
                    //    window.location.href = '/AddDegrees'
                    //    , 500);

                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
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
