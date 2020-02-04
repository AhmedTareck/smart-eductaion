
import moment from 'moment';
export default {
    name: 'SkedjuleInfo',

    created() {
        
        this.selectedPresness = this.$parent.selectedPresness;
        this.GetPresnessInfo();
    },
    data() {
        return {

            state: 0,
            selectedPresness: [],
            student: [],

            skedjule: {
                EventSelectd: '',

                satrdayOne: '',
                satrdaytwo: '',
                satrdayTree: '',
                satrdayFour: '',
                satrdayFive: '',
                satrdaySex: '',
                satrdaySeven: '',

                sunOne: '',
                suntwo: '',
                sunTree: '',
                sunFour: '',
                sunFive: '',
                sunSex: '',
                sunSeven: '',

                mOne: '',
                mtwo: '',
                mTree: '',
                mFour: '',
                mFive: '',
                mSex: '',
                mSeven: '',

                TuOne: '',
                Tutwo: '',
                TuTree: '',
                TuFour: '',
                TuFive: '',
                TuSex: '',
                TuSeven: '',

                ThOne: '',
                Thtwo: '',
                ThTree: '',
                ThFour: '',
                ThFive: '',
                ThuSex: '',
                ThSeven: '',

                wOne: '',
                wtwo: '',
                wTree: '',
                wFour: '',
                wFive: '',
                wuSex: '',
                wSeven: ''
            }

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
        GetPresnessInfo() {
            this.$blockUI.Start();
            this.$http.GetPresnessInfo(this.selectedPresness.id)
                .then(response => {

                    this.$blockUI.Stop();
                    this.student = response.data.student;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                });
        },

        back() {
            this.$parent.state = 0;
        }
    }
}
