import AddDegrees from './AddDegrees/AddDegrees.vue'
﻿import moment from 'moment';
export default {
    name: 'Degrees',
    
    created() { 
        this.Getdegrees();
    },
    components: {
        'AddDegrees': AddDegrees,
    },
    data() {
        return {


            Years:[],
            YearSelected:'',

            Events:[],
            EventSelectd:'',


            student: [],
            selectedHomeWorck: [],

            searchItem: '',

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            degrees: [],
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
       

        serachStudent() {
            
            this.$blockUI.Start();
            this.$http.serachStudent(this.searchItem)
                .then(response => {

                    this.$blockUI.Stop();
                    this.student = response.data.students;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        Getdegrees(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.Getdegrees(this.pageNo, this.pageSize)
                .then(response => {

                    this.$blockUI.Stop();
                    this.degrees = response.data.degreess;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        deltedegrees(id) {


            this.$confirm('سيؤدي ذلك إلى حدف السجل  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deltedegrees(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.Getdegrees();
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
