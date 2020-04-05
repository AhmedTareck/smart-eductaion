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
            year: [],

            SubjectName: [],
            shapterName: [],
            EventName: [],

            ruleForm: {
                shapterSelected: '',
                Name:'',
                Number: '',
                decreption:'',
                yearSelectedId: '',
                subjectSeletect: '',
                Photo: [],
                Video: '',
                sound: [],
                attashFile: [],
                EventId: '',
               
            },


        };


    },
    methods: {

        getEventName() {
            //this.SubjectName = [];
            //this.form.SubjectId = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getEventName(this.ruleForm.subjectSeletect)

                .then(response => {

                    this.$blockUI.Stop();
                    this.EventName = response.data.eventinfo;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },



        handleRemove(file, fileList) {
            console.log(file, fileList);
        },
        handlePreview(file) {
            console.log(file);
        },
        handleExceed(files, fileList) {
            this.$message.warning(`لايمكن تحميل أكتر من 5 ملفات `);
        },
        beforeRemove(file, fileList) {
            return this.$confirm(`هل انت متأكد من عملية إلغاء ${file.name} ?`);
        },


        //Image Upload
        handleExceedImage(files, fileList) {
            this.$message.warning(`لايمكن تحميل أكتر من 10 صور `);
        },
        
        
        handleRemoveImage(file) {
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                $this.ruleForm.Photo.splice($this.ruleForm.Photo.indexOf(reader.result), 1);
            }
        },
        ImageChanged(file, fileList) {

            console.log(file.raw.type);

            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                var obj =
                {
                    FileName: file.raw.name,
                    FileBase64: reader.result,
                };
                $this.ruleForm.Photo.push(obj);
            }
            console.log($this.ruleForm.Photo);
        },

        //PDF Upload
        handleExceedPDF(files, fileList) {
            this.$message.warning(`لايمكن تحميل أكتر من  ملف `);
        },
        handleRemovePDF(file) {
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                $this.ruleForm.attashFile.splice($this.ruleForm.attashFile.indexOf(reader.result), 1);
            }
        },
        PdfChanged(file, fileList) {


            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                var obj =
                {
                    fileName: file.raw.name,
                    fileBase64: reader.result,
                };
                $this.ruleForm.attashFile.push(obj);
            }
            console.log($this.ruleForm.attashFile);
        },

        //Sound Upload
        handleExceedSound(files, fileList) {
            this.$message.warning(`لايمكن تحميل أكتر من  صوت `);
        },
        handleRemoveSound(file) {
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                $this.ruleForm.sound.splice($this.ruleForm.sound.indexOf(reader.result), 1);
            }
        },
        SoundChanged(file, fileList) {


            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                var obj =
                {
                    fileName: file.raw.name,
                    fileBase64: reader.result,
                };
                $this.ruleForm.sound.push(obj);
            }
            console.log($this.ruleForm.sound);
        },



        //Vedio Upload
        handleExceedVedio(files, fileList) {
            this.$message.warning(`لايمكن تحميل أكتر من  فيديو `);
        },
        handleRemoveVedio(file) {
            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                $this.ruleForm.Video.splice($this.ruleForm.Video.indexOf(reader.result), 1);
            }
        },
        VedioChanged(file, fileList) {

            var $this = this;
            var reader = new FileReader();
            reader.readAsDataURL(file.raw);
            reader.onload = function (e) {
                var obj =
                {
                    fileName: file.raw.name,
                    fileBase64: reader.result,
                };
                $this.ruleForm.Video.push(obj);
            }
            console.log($this.ruleForm.Video);
        },





         

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
            //this.shapterName = [];
            //this.ruleForm.shapterSelected = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getShapterName(this.ruleForm.EventId)

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
                if (!valid) {
                    return false;
                }  
            });

          

            this.$http.addLecture(this.ruleForm)
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
