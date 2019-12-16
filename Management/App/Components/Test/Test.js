
import moment from 'moment';
import CryptoJS from 'crypto-js';

export default {
    name: 'Test',    
    created() {
    },


    filters: {
        moment: function (date) {
            if (date === null) {
                return "فارغ";
            }
           // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },
    data() {
        return { 
            Branch:[],
            SelectdBrach: ''
        };
    },
methods: {


    Getusers(){
    
        

        this.$blockUI.Start();
        this.$http.GetU()

            .then(response => {
                this.$blockUI.Stop();
                this.BrancheModel='';
                this.Branches = response.data.branches;
            })
            .catch((err) => {
                this.$blockUI.Stop();
                console.error(err);
                this.pages = 0;
            });
    }
        
    }    
}
