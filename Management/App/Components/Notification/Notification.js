//import addUsers from './AddUsers/AddUsers.vue';
//import ParentsProfile from './ParentsProfile/ParentsProfile.vue';
import moment from 'moment';
import CryptoJS from 'crypto-js';
export default 
{

        name: 'Notification',
    
        created() 
        {


            this.GetNotifi(this.pageNo);
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
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },
    
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            
            state: 0,

            notifi:[],
            

        };
        },


    methods: 
    {
        GetNotifi(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();

            this.$http.GetNotifi(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.notifi = response.data.notif;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.pages = 0;
                });
        },

        
    }
};
