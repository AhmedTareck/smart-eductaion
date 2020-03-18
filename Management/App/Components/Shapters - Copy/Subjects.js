﻿import moment from 'moment';
import EditSubjects from './EditSubjects/EditSubjects.vue';
import AddSubjects from './AddSubjects/AddSubjects.vue';
export default {
    name: 'Subject',
    
    created() { 
        this.getyearName();
        this.GetSubjectInfo();
    },
    components: {
        'EditSubjects': EditSubjects,
        'AddSubjects': AddSubjects,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Subject: [],

            year: [],
            yearSelected:'',
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

        GetSubjectInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetSubjectInfo(this.pageNo, this.pageSize, this.yearSelected)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Subject = response.data.subjects;
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

        addYers() {
            this.state = 1;
        },


        deleteSubject(id) {


            this.$confirm('سيؤدي ذلك إلى حدف المادة الدراسية  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deleteSubject(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetSubjectInfo();
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
