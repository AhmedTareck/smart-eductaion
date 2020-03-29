
export default {
name: 'AddExaming',    
created() {
    this.AddLecture=false;
    this.UpdateAction=0;
},



props: ['QuestionList'],

    data() {
        return {

            body: {
                Status:null,
                Name:'',
                Number:'',
                FullMarck:'',
                Lenght: '',
                Questions: [],
                EventId: null,
                AcademicYearId:null,
                SubjectId: null
            },

            Question: {
                Number:'',
                Points:'',
                Question:'',
                Answer:'',
                A1:'',
                A2:'',
                A3:'',
                A4: '',
                QuestionTypeID: null,
                QuestionType: [{
                    id: 0,
                    type: "إختار نوع السؤال"
                },
                {
                    id: 1,
                    type: "صح/خطاء"
                },
                {
                    id: 2,
                    type: "سؤال متعدد الإختيارات"
                 }],
                AnswerType: [{
                    id: 0,
                    name: "إختار الإجابة"
                },
                {
                    id: 1,
                    name: "صح"
                },
                {
                    id: 2,
                    name: "خطاء"
                }]

            },
            
            ExamType: [{
                id: 0,
                name: "إختيار الإجابة الصحيحة"
            },
            {
                id: 1,
                name: "عام"
            },
            {
                id: 2,
                name: "خاص"
             }],

            Answers: [{
                id: 0,
                name: "إختار نوع الإمتحان"
            },
            {
                id: 1,
                name: "الخيار الأول"
            },
            {
                id: 2,
                name: "الخيار التاني"
            },
            {
               id: 3,
                name: "الخيار الثالت"
            },
            {
               id: 4,
                name: "الخيار الرابع"

            }],
            Events: [{ id: 0, name:"إختار الكورس"}],
            AcademicYears: [{ id: 0, name: "إختار السنة الدراسية" }],
            Subjects:[]

        };
    },
    methods: {

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addQuestion(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },
        
        addQuestion(formName) {
            var question = {
                Number: this.Question.Number,
                Points: this.Question.Points,
                Question: this.Question.Question,
                Answers: this.chooseAnswersType(this.Question.QuestionTypeID),
                Status: this.Question.Answer
            };

            this.body.Questions.push(question);
            this.resetForm(formName);
        },

        chooseAnswersType(QuestionTypeID) {

            if (QuestionTypeID === 1)
                return [{
                    ExamAnswers: "صح"
                }, {
                    ExamAnswers: "خطاء"
                }];
            else if (QuestionTypeID === 2)
                return [{
                    ExamAnswers: this.Question.A1
                }, {
                    ExamAnswers: this.Question.A2
                }, {
                    ExamAnswers: this.Question.A3
                }, {
                    ExamAnswers: this.Question.A4
                }];

        },

        removeQuestion(index) {
            this.body.Questions.splice(index, 1);
        },

        submitExamForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addExam(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },
        addExam(formName) {
            this.$blockUI.Start();
            this.$http.addExam(this.body)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.resetForm(formName);
                    this.body.Questions=[],
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

        async selectExamType(e) {
            this.body.Status = null;
            this.$emit('input', e);
            this.body.Status = e;
            this.body.AcademicYearId = null;
            this.body.EventId = null;
            this.body.SubjectId = null;
            this.Subjects.length = 0;

            if (this.body.Status === 1) {

                if (this.AcademicYears.length <= 1) {
                   
                    this.$http.getAcademicYears().then(response => {
                        response.data.forEach(item => {
                            this.AcademicYears.push(item);
                        });
                    });
                }

            } else if (this.body.Status === 2) {
              
                if (this.Events.length <= 1) {
                    this.$http.getEvents().then(response => {
                        response.data.forEach(item => {
                            this.Events.push(item);
                        });
                    });
                }
            }
        },
        selectAnswers(e) {
            this.$emit('input', e);
            this.Question.Answer = e;
        },
        selectAcademicYears(e) {

            this.$emit('input', e);
            this.body.AcademicYearId = e;
            this.Subjects.length = 0;
            
            this.Subjects.push({ id: 0, name: "إختار المادة الدراسية" });
            this.$http.getSubjects(this.body.AcademicYearId).then(response => {
                  response.data.forEach(item => {
                      this.Subjects.push(item);
                  });
            });
        },
        selectSubject(e) {
            this.$emit('input', e);
            this.body.SubjectId = e;
        },
        selectEvents(e) {
            this.$emit('input', e);
            this.body.EventId = e;
        },
        selectQuestionType(e) {
            this.Question.Answer = null;
            this.$emit('input', e);
            this.Question.QuestionTypeID = e;
        },
        labelAnswer(answerId) {
            if (this.Question.QuestionTypeID === 1)
                switch (answerId) {
                    case 1:
                        return "صح";
                    case 2:
                        return "خطاء";
                }
            else if (this.Question.QuestionTypeID === 2)
                return answerId;
        }

    }

}
