﻿import moment from 'moment';
import EditLectures from './EditLectures/EditLectures.vue';
import AddLectures from './AddLectures/AddLectures.vue';
export default {
    name: 'Lectures',
    
    created() { 
        this.getyearName();
        this.getLectures();
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

            year: [],

            SubjectName: [],
            shapterName: [],

            shapterSelected: '',
            yearSelectedId: '',
            subjectSeletect: '',


            selectedItem: '',

            info:[],

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

        getSubject() {
            this.SubjectName = [];
            this.subjectSeletect = '';
            this.shapterName = [];
            this.shapterSelected = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getSubject(this.yearSelectedId)

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
            this.shapterName = [];
            this.shapterSelected = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getShapterName(this.subjectSeletect)

                .then(response => {

                    this.$blockUI.Stop();
                    this.shapterName = response.data.shapterNames;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getLectures(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();

            this.$http.getLectures(this.pageNo, this.pageSize, this.shapterSelected)
                .then(response => {
                    this.$blockUI.Stop();
                    this.info = response.data.lectures;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.pages = 0;
                });
        },

        editLecture(item) {
            this.selectedItem = item;
            this.state = 2;
        },

        deletelecture(id) {


            this.$confirm('سيؤدي ذلك إلى حدف المحاضرة  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deletelecture(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.getLectures();
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
