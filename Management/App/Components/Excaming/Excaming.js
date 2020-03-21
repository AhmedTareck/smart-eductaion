import moment from 'moment';
export default {
    name: 'Excaming',
    //components: {
    //    'EditExam': EditExaming
    //},
    
    created() {
        this.GetExamingInfo();

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

    data() {
        return {
            state: 0,

            pageNo: 1,
            pageSize: 10,
            pages: 0,

            Examing: [],

            selectedExam:[],
        };
    },
    methods: {

        GetExamingInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetExamingInfo(this.pageNo, this.pageSize)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Examing = response.data.exams;
                    this.pages = response.data.count;

                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        DeleteExaming(id) {


            this.$confirm('سيؤدي ذلك إلى حدف الإختبار  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.DeleteExaming(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetExamingInfo();
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
