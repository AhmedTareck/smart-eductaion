export default {
    name: 'AddAdsInfo',
    created() {

        this.getyearName();

        this.type = [
            {
                id: 1,
                name: "عام"
            }, {
                id: 2,
                name: 'خاص بطلبة المركز'
            },


        ];

    },

    data() {

        return {

            type: [],

            photo: [],
            Video: [],
            sound: [],
            attashFile: [],

            year: [],

            SubjectName: [],
            shapterName: [],

            ruleForm: {
                
                shapterSelected: '',
                Name:'',
                Number: '',
                decreption:'',

                yearSelectedId: '',
                subjectSeletect: '',


            },


        };


    },
    methods: {

        getyearName() {

            this.$blockUI.Start();
            this.$http.getyearName()
                .then(response => {

                    this.$blockUI.Stop();
                    this.year = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getSubject() {
            this.SubjectName = [];
            this.ruleForm.subjectSeletect = '';
            this.shapterName = [];
            this.ruleForm.shapterSelected = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getSubject(this.ruleForm.yearSelectedId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.SubjectName = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getShapterName() {
            this.shapterName = [];
            this.ruleForm.shapterSelected = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getShapterName(this.ruleForm.subjectSeletect)

                .then(response => {

                    this.$blockUI.Stop();
                    this.shapterName = response.data.shapterNames;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },


        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.UploadImage();
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


        UploadImage() {
            this.$blockUI.Start();
            var obj = {
                Photo: this.photo,
               
                shapterSelected: this.ruleForm.shapterSelected,
                Name: this.ruleForm.Name,
                Number: this.ruleForm.Number,
                decreption: this.ruleForm.decreption,
            };
            this.$http.addLecture(obj)
                .then(response => {
                    this.$blockUI.Stop();
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
