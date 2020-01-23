import moment from 'moment';
export default {
    name: 'StudentProfile',
    
    created() { 
        this.getStudentById();
        this.sex = [
            {
                id: 1,
                name: "دكر"
            },
            {
                id: 2,
                name: 'انتي'
            }
        ];
    },
    components: {
    },
    data() {
        return {
            selectedStudent:[],
            sex: [],
            PersnalInfoForm: {
                firstName: '',
                fatherName: '',
                grandFatherName: '',
                matherName: '',
                surName: '',
                StudentId:'',

                selectedSex: [],

                Adrress: '',
                phone: '',
                parnsPhone: '',
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
        getStudentById()
        {
            this.$blockUI.Start();
            this.$http.getStudentById(this.$parent.selectedStudent.studentId)
                .then(response => {

                    this.$blockUI.Stop();
                    this.selectedStudent = response.data.student;
                    this.PersnalInfoForm.firstName = this.selectedStudent[0].firstName;
                    this.PersnalInfoForm.StudentId = this.selectedStudent[0].studentId;
                    this.PersnalInfoForm.fatherName = this.selectedStudent[0].fatherName;
                    this.PersnalInfoForm.grandFatherName = this.selectedStudent[0].grandFatherName;
                    this.PersnalInfoForm.surName = this.selectedStudent[0].surName;
                    this.PersnalInfoForm.matherName = this.selectedStudent[0].matherName;
                    this.PersnalInfoForm.Adrress = this.selectedStudent[0].address;
                    this.PersnalInfoForm.selectedSex = this.selectedStudent[0].selectedSex;
                    this.PersnalInfoForm.phone = this.selectedStudent[0].phone;
                    this.PersnalInfoForm.parnsPhone = this.selectedStudent[0].parnsPhone;
                    
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        back() {
            this.$parent.state = 0;
        },


        submitForm() {

            this.$http.EditStudent(this.PersnalInfoForm)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.$parent.GetStudent();
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
