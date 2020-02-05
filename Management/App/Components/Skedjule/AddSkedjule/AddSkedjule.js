export default {
    name: 'AddSkedjule',

    created() {
        this.GetYears();

        this.Days = [
            {
                id: 1,
                name: "السبت"
            },
            {
                id: 2,
                name: 'الأحد'
            },
            {
                id: 3,
                name: 'الإتنين'
            },
            {
                id: 4,
                name: 'التلاتاء'
            },
            {
                id: 5,
                name: 'الإربعاء'
            },
            {
                id: 6,
                name: 'الخميس'
            }

        ];
    },
    data() {
        return {
            Days: [],

            Years: [],
            Events: [],
            Subject: [],

            YearSelected: '',
            
            SubjectSelected: '',


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
            this.resetForm();
            this.getSubject();
            this.skedjule.EventSelectd = '';
            this.SubjectSelected = '';
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

        getSubject() {
            this.$blockUI.Start();
            this.$http.getSubject(this.YearSelected)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Subject = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        AddSkedjule() {

            this.$http.AddSkedjule(this.skedjule)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.resetForm();
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });

        },

        resetForm() {
            this.skedjule.EventSelectd = '';
            this.SubjectSelected = '';

            this.skedjule.satrdayOne = '';
            this.skedjule.satrdaytwo = '';
            this.skedjule.satrdayTree = '';
            this.skedjule.satrdayFour = '';
            this.skedjule.satrdayFive = '';
            this.skedjule.satrdaySex = '';
            this.skedjule.satrdaySeven = '';

            this.skedjule.sunOne = '';
            this.skedjule.suntwo = '';
            this.skedjule.sunTree = '';
            this.skedjule.sunFour = '';
            this.skedjule.sunFive = '';
            this.skedjule.sunSex = '';
            this.skedjule.sunSeven = '';

            this.skedjule.mOne = '';
            this.skedjule.mtwo = '';
            this.skedjule.mTree = '';
            this.skedjule.mFour = '';
            this.skedjule.mFive = '';
            this.skedjule.mSex = '';
            this.skedjule.mSeven = '';

            this.skedjule.TuOne = '';
            this.skedjule.Tutwo = '';
            this.skedjule.TuTree = '';
            this.skedjule.TuFour = '';
            this.skedjule.TuFive = '';
            this.skedjule.TuSex = '';
            this.skedjule.TuSeven = '';

            this.skedjule.ThOne = '';
            this.skedjule.Thtwo = '';
            this.skedjule.ThTree = '';
            this.skedjule.ThFour = '';
            this.skedjule.ThFive = '';
            this.skedjule.ThuSex = '';
            this.skedjule.ThSeven = '';

            this.skedjule.wOne = '';
            this.skedjule.wtwo = '';
            this.skedjule.wTree = '';
            this.skedjule.wFour = '';
            this.skedjule.wFive = '';
            this.skedjule.wuSex = '';
            this.skedjule.wSeven = '';
            }

    }
}
