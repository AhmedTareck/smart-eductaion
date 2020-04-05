import moment from 'moment';
export default {
    name: 'EditSubjects',
    
    created() {
        this.getyearName();
        this.getTeatcherName();

        this.form.Id = this.$parent.selectedStudent.id;
        this.form.yearId = this.$parent.selectedStudent.yearId;
        this.form.TeacherId = this.$parent.selectedStudent.teacherId;
        this.form.SubjectId = this.$parent.selectedStudent.subjectId;
        this.form.Name = this.$parent.selectedStudent.name;
        this.form.Discreptions = this.$parent.selectedStudent.discreptions;
    },
    components: {
    },
    data() {
        return {
            year: [],


            subjects: [],
            teachers: [],


            form: {

                yearId: '',
                Id: '',

                TeacherId: '',
                SubjectId: '',
                Name: '',
                Discreptions: '',
            },
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {
        back() {
            this.$parent.state = 0;
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

            this.$blockUI.Start();
            this.$http.getSubject(this.form.yearId)
                .then(response => {

                    this.$blockUI.Stop();
                    this.subjects = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getTeatcherName() {

            this.$blockUI.Start();
            this.$http.getTeatcherName()
                .then(response => {

                    this.$blockUI.Stop();
                    this.teachers = response.data.teacher;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.editEvent();
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },


        editEvent() {
            this.$blockUI.Start();
            this.$http.editEvent(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.getEventInfo();
                    this.$parent.state = 0;
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        }
    }    
}
