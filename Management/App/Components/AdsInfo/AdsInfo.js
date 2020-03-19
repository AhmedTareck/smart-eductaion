import moment from 'moment';
export default 
{

        name: 'AdsInfo',
    
        created() 
        {


            this.GetInfo(this.pageNo);
    },



    components: {
        //'add-Users': addUsers,
        //'ParentsProfile': ParentsProfile
    },
    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
             return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            //return moment(date).format('MMMM Do YYYY');
        }
    },
    
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            
            state: 0,


            info:[],
            

        };
        },


    methods: 
    {
        GetInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();

            this.$http.GetAds(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.info = response.data.adss;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.pages = 0;
                });
        },

        deleteAds(id) {


            this.$confirm('سيؤدي ذلك إلى حدف  اللإعلان  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deleteAds(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetInfo();
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
};
