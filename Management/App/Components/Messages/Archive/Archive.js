﻿import MassageDetals from './MassageDetals/MassageDetals.vue';
import moment from 'moment';

export default {
    name: 'Archive',    
    created() {
  
        this.GetMassages(this.pageNo);
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

        GetMassages(pageNo) {
            this.pageNo = pageNo;
                if (this.pageNo === undefined) {
                    this.pageNo = 1;
                }
            this.$blockUI.Start();
            this.$http.GetReceivedMassage(this.pageNo, this.pageSize,2)//reseved Massage
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

        //1-AddToBockmarck
        //2-RemoveBockmarck
        //3-SetReadStatus
        //4-ChangeUnReadState
        //5-AddToArcive
        //6-removeArcive

        ChangeMassageStatus(item,operation)
        {
            var status=0;
            if(operation==1)
            {
                if(item.status==1 || item.status==3 || item.status==5 || item.status==6)
                {
                    return;
                }else  if(item.status==0)
                {
                    status=3;
                }else if(item.status==2)
                {
                    status=5;
                }else if(item.status==4)
                {
                    status=6;
                }else if(item.status==7)
                {
                    status=1;
                }
            }else if(operation==2)
            {
                var status=0;
                if(item.status==0 || item.status==2 || item.status==4 || item.status==7)
                {
                    return;
                }else  if(item.status==1)
                {
                    status=7;
                }else if(item.status==3)
                {
                    status=0;
                }else if(item.status==5)
                {
                    status=2;
                }else if(item.status==6)
                {
                    status=4;
                }
            }else if(operation==3)
            {
                if(item.status==2 || item.status==4 || item.status==5 || item.status==6)
                {
                    return;
                }else  if(item.status==0)
                {
                    status=4;
                }else if(item.status==1)
                {
                    status=5;
                }else if(item.status==3)
                {
                    status=6;
                }else if(item.status==7)
                {
                    status=2;
                }
            }else if(operation==4)
            {
                if(item.status==0 || item.status==1 || item.status==3 || item.status==7)
                {
                    return;
                }else  if(item.status==2)
                {
                    status=7;
                }else if(item.status==4)
                {
                    status=0;
                }else if(item.status==5)
                {
                    status=1;
                }else if(item.status==6)
                {
                    status=3;
                }
            }else if(operation==5)
            {
                if(item.status==0 || item.status==3 || item.status==4 || item.status==6)
                {
                    return;
                }else  if(item.status==1)
                {
                    status=3;
                }else if(item.status==2)
                {
                    status=4;
                }else if(item.status==5)
                {
                    status=6;
                }else if(item.status==7)
                {
                    status=0;
                }
            }
            else if(operation==6)
            {
                if(item.status==0)
                {
                    status=7;
                }else if(item.status==3)
                {
                    status=1;
                }else if(item.status==4)
                {
                    status=2;
                }else if(item.status==6)
                {
                    status=5;
                }
            }

            var MassageHint="";
            if(operation==1)
            {
                MassageHint="تم تحديد الرسالة كمفظلة";
            }else if(operation==2)
            {
                MassageHint="تم إزالة الرسالة من الرسائل المفضلة";
            }else if(operation==5)
            {
                MassageHint="تم إضافة الرسالة إلي الأرشيف";
            }

            this.$http.ChangeMassageState(item.conversationId,status)
                    .then(response => {   
                        this.GetMassages(this.pageNo);
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            showClose: true,
                            message: '<strong>' + err.response.data+'</strong>'
                        });  
                    });

        },

        DeleteMassage(item)
        {
            this.$http.DeleteMassage(item.conversationId)
                .then(response => {    
                    this.$message({
                        type: 'success',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>'+response.data+'</strong>'
                    });  
                    this.GetMassages(this.pageNo);
                })
                .catch((err) => {
                    this.$message({
                        type: 'error',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        showClose: true,
                        message: '<strong>' + err.response.data+'</strong>'
                    });  
                });

        },

        MassageDetals(item)
        {
            this.ChangeMassageStatus(item,4)
            this.SelectedMassages=item;
            this.state=1;
        }
       
    }    

}