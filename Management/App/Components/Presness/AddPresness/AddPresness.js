
import moment from 'moment';
export default {
    name: 'AddPresness',

    created() {
        this.GetYears();
    },
    data() {
        return {

            state: 0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Years: [],
            

            Events: [],

            YearSelected: '',
            EventSelectd: '',

            Students: [],

            LectureDate: '',
            
            

            selectedStudent: [],

            checked:'',
            checked1: '',

            presness: {
                YearSelected: '',
                EventSelectd: '',
                LectureDate: '',
                Students: [],
            },

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

        GetYears() {
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

        getEvents() {
            this.Students = [],
            this.LectureDate='',
            this.EventSelectd= '';
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

        
        viewStudent(item) {
            this.LectureDate = '',
            this.state = 2;
            this.selectedStudent = item;
        },

        GetStudent(pageNo) {
            this.Students=[],
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetStudent(this.pageNo, this.pageSize, this.EventSelectd)
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

        addPresness() {
            this.presness.students = this.Students;
            this.presness.YearSelected = this.YearSelected;
            this.presness.EventSelectd = this.EventSelectd;
            this.presness.LectureDate = this.LectureDate;            


            this.$http.addPresness(this.presness)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.YearSelected = '';
                    this.EventSelectd = '';
                    this.LectureDate = '';
                    this.Students = '';
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        }

    }
}
