
﻿import moment from 'moment';
import addStudent from './AddStudent/AddStudent.vue';
import StudentProfile from './StudentProfile/StudentProfile.vue';
export default {
    name: 'Student',
    
    created() { 
        this.GetStudent();
        this.GetYears();
    },
    components: {
        'add-Student': addStudent,
        'StudentProfile': StudentProfile,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Years:[],
            YearSelected:'',

            Events:[],
            EventSelectd:'',

            Students:[],

            selectedStudent:[],
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
        AddStudent()
        {
            this.state = 1;
        },

        GetYears(){
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

        getEvents() 
        {
            this.EventSelectd='';
            this.GetStudent();
            this.$blockUI.Start();
            this.$http.GetEvents(this.YearSelected)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Events = response.data.events;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        GetStudent(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetStudent(this.pageNo, this.pageSize,this.EventSelectd)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Students = response.data.students;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        viewStudent(item)
        {
            this.state=2;
            this.selectedStudent=item;
        },


        delteStudent(id) {


            this.$confirm('سيؤدي ذلك إلى حدف الطالب  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.delteStudent(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetStudent();
                    })
                    .catch((err) => {
                        this.$blockUI.Stop();
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            });
        },
    }    
}
