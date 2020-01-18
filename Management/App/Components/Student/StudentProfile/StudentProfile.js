import moment from 'moment';
export default {
    name: 'StudentProfile',
    
    created() { 
        this.getStudentById();
        this.PersnalInfoForm.firstName=this.selectedStudent.firstName;
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


                selectedSex: [],

                address: '',
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
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        }
    }    
}
