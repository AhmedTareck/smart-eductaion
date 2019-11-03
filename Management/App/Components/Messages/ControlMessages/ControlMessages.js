import MassageDetals from './MassageDetals/MassageDetals.vue';
import moment from 'moment';

export default {
    name: 'ControlMessages',    
    created() {
  
        this.GetControlMessages(this.pageNo);
    },

    components: {
        'MassageDetals': MassageDetals,
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return "فارغ";
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('h:mm A');
        }
    },

    data() {
        return {  
            pageNo: 1,
            pageSize: 10,
            pages: 0,  
            state:0,
            
            Massages:[],
            SelectedMassages:[],
        };
    },

    methods: 
    {

        GetControlMessages(pageNo) {
          
            this.pageNo = pageNo;
                if (this.pageNo === undefined) {
                    this.pageNo = 1;
                }
            this.$blockUI.Start();
            this.$http.GetControlMessages(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Massages = response.data.praticipations;
             
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

     
        MassageDetals(item)
        {

        
            this.SelectedMassages=item;
            this.state=1;
        }
       
    }    

}
