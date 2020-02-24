
import moment from 'moment';
export default {
    name: 'AddDegrees',

    created() {
        this.GetYears();
    },
    components: {
    },
    data() {
        return {

            Years: [],

            Events: [],

            Students:[],

            photo: [],


            selectedHomeWorck: {
                eventId: '',
                yearId:'',
                name: '',
                lastDayDilavary: '',
                disctiption: '',
                SubjectSelected: '',
                studentId:'',

            },
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
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

        GetYears() {
            this.$blockUI.Start();
            this.$http.GetYears()
                .then(response => {

                    this.$blockUI.Stop();
                    this.Years = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getEvents() {
            this.EventSelectd = '';
            this.getSubject();
            this.$blockUI.Start();
            this.$http.GetEvents(this.selectedHomeWorck.yearId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Events = response.data.events;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        AddHomeWorck(formName) {

            this.$http.AddHomeWorck(this.selectedHomeWorck)
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

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        getSubject() {
            this.Subject = [];
            this.selectedHomeWorck.eventId = '';
            this.Students = [];
            this.selectedHomeWorck.SubjectSelected = '';
            this.$blockUI.Start();
            this.$http.getSubject(this.selectedHomeWorck.yearId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Subject = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        GetStudent() {
            this.Students = [];
            this.selectedHomeWorck.SubjectSelected = '';
            this.$blockUI.Start();
            this.$http.GetStudentByEvent(this.selectedHomeWorck.eventId)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Students = response.data.students;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
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
                $this.UploadImage();
            };
            reader.onerror = function (error) {
                $this.photo = null;
            };
            reader.readAsDataURL(files[0]);
        },

        UploadImage() {
            console.log(this.selectedHomeWorck.studentId);
            this.$blockUI.Start();
            var obj = {
                Photo: this.photo,
                StudentId: this.selectedHomeWorck.studentId
            };
            this.$http.UploadDegregesImage(obj)
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


    }
}
