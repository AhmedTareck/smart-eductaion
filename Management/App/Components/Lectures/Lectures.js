﻿import moment from 'moment';
import EditLectures from './EditLectures/EditLectures.vue';
import AddLectures from './AddLectures/AddLectures.vue';
export default {
    name: 'Lectures',
    
    created() { 
        this.getyearName();
        this.GetSubjectInfo();
        this.getShpater();
    },
    components: {
        'EditLectures': EditLectures,
        'AddLectures': AddLectures,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Subject: [],

            year: [],
            yearSelected: '',

            SubjectName: [],
            SubjectSelected: '',



            shapters: [],
            selectedItem: [],

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

        getShpater(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.getShpater(this.pageNo, this.pageSize, this.SubjectSelected)
                .then(response => {

                    this.$blockUI.Stop();
                    this.shapters = response.data.shapter;
                    this.pages = response.data.count;

                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
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
            this.SubjectSelected = '';
            this.getShpater();
            this.$blockUI.Start();
            this.$http.getSubject(this.yearSelected)

                .then(response => {

                    this.$blockUI.Stop();
                    this.SubjectName = response.data.subject;
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
            this.selectedItem=item;
        },

        addYers() {
            this.state = 1;
        },


        delteShpter(id) {


            this.$confirm('سيؤدي ذلك إلى حدف الشابتر  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.delteShpter(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.getShpater();
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
