import EditExam from './EditExam/EditExam.vue'
import GridsInfo from './GridsInfo/GridsInfo.vue'
﻿import moment from 'moment';
export default {
    name: 'Exam',
    
    created() { 
        this.GetYears();
        this.GetExams();
    },
    components: {
        'EditExam': EditExam,
        'GridsInfo': GridsInfo,
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


            Exams: [],
            selectedExams:[],
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
            this.GetExams();
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

        GetExams(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetExams(this.pageNo, this.pageSize, this.YearSelected,this.EventSelectd)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Exams = response.data.exam;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        editExams(item) {
            this.selectedExams = item;
            this.state = 1;
        },

        GridsInfo(item) {
            this.selectedExams = item;
            this.state = 2;
        },

        delteExams(id) {


            this.$confirm('سيؤدي ذلك إلى حدف  الإختبار  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.delteExams(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetExams();
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
