
import moment from 'moment';
import 'quill/dist/quill.core.css';
import 'quill/dist/quill.snow.css';
import 'quill/dist/quill.bubble.css';
import Resend from './Resend/Resend.vue';
import { quillEditor } from 'vue-quill-editor';

export default {
name: 'MassageDetals',    
created() {
    this.MassageDetals=this.$parent.SelectedMassages;
    this.GetReplayes(this.pageNo);
    this.MassageStatus=this.MassageDetals.status;
    setInterval(() => this.GetReplayes(this.pageNo), 10000);  
    //this.GetMassages(this.pageNo);
},
    components: {
        'Resend': Resend,
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
            MassageDetals:[],
            Replayes:[],
            EditMessage:[],
            content: "",
            ReplayBody:"",
            MassageStatus:0,
            Attachment:[],
            editorOption: {
                //debug: 'info',
                //placeholder: " ",
                //readOnly: true,
                //theme: 'snow',
                //modules: {
                //    toolbar: [
                //        ['bold', 'italic', 'underline'],
                //        ['code-block'],
                //        [{ 'color': [] }, { 'background': [] }],
                //        [{ 'list': 'ordered' }, { 'list': 'bullet' }],
                //        [{ 'direction': 'rtl' }],
                //        [{ 'align': [] }],

                //    ],
                //},
            },
        };
    },

methods: 
    {
        GetReplayes(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            } 

            this.$http.GetReplayes(this.pageNo, this.pageSize,this.$parent.SelectedMassages.conversationId)
                .then(response => {
                    this.Replayes = response.data.replayesLists;
                    this.Attachment = response.data.attachments;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    console.error(err);
                    this.pages = 0;
                });
        },

        //1-AddToBockmarck
        //2-RemoveBockmarck
        //3-SetReadStatus
        //4-ChangeUnReadState
        //5-AddToArcive

        ChangeMassageStatus(item,operation)
        {debugger
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

            this.$http.ChangeMassageState(item.participationsId,status)
                    .then(response => { 
                        this.MassageStatus=status;
                        this.MassageDetals.status=status;
                        if(operation==5)
                        {
                            this.$parent.state=0;
                        }
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
    Resend(MassageDetals) {
     
        this.EditMessage = MassageDetals;
        this.state = 1;
    },
        DeleteMassage(item)
        {
            this.$http.DeleteMassage(item.participationsId)
                .then(response => {    
                    this.$message({
                        type: 'success',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>'+response.data+'</strong>'
                    });  
                    this.$parent.GetMassages();
                    this.$parent.state=0;
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

        AddReplay()
        {
            this.$http.AddReplay(this.$parent.SelectedMassages.conversationId,this.ReplayBody)
                .then(response => {    
                    this.$message({
                        type: 'success',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>'+response.data+'</strong>'
                    });  
                    this.ReplayBody = '';
                    this.GetReplayes(this.pageNo);

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

        Back()
        {
            this.$parent.state=0;
        }
       
    }    

}
