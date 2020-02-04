
import moment from 'moment';
export default {
    name: 'GridsInfo',

    created() {
        this.ExamSelected = this.$parent.selectedExams;

        this.getGridsInfo();
    },
    data() {
        return {

            ExamSelected: [],

            state: 0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,


            Students: [],


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

        getGridsInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.getGridsInfo(this.pageNo, this.pageSize,this.$parent.selectedExams.id)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Students = response.data.exam;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        back() {
            this.$parent.state = 0;
        }
    }
}
