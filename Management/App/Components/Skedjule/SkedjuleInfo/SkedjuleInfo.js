
import moment from 'moment';
export default {
    name: 'SkedjuleInfo',

    created() {
        
        this.selectedSkedjule = this.$parent.selectedPresness;
        this.GetSkedjuleInfo();
    },
    data() {
        return {

            state: 0,
            selectedSkedjule: [],
            student: [],
            Subject: [],
            SkedjuleInfo:[],

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
        
        GetSkedjuleInfo() {
            var id = this.selectedSkedjule.id;
            this.$blockUI.Start();
            this.$http.GetSkedjuleInfo(id)
                .then(response => {

                    this.$blockUI.Stop();
                    this.SkedjuleInfo = response.data.skedjules;
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
