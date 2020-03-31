

export default {
    name: 'Topics',
    components: {

    },
    created() {
    },
    data() {
        return {
<<<<<<< HEAD
            selectedChapterIndex: null,
            highlightedLectureIndex: null,
            selectedLectureIndex: null,
            savedSelectedChapterIndex :null,
            hover: false,
            contentLink:'#Content',
            chapters: [{
                id: 0,
                title: "الفصل الأول",
                lectures: [{
                    Id: 0,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "المحاضرة الأولى"

                }, {
                    Id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "المحاضرة الثانية"
                },
                {
                    Id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الثالثة"
                }]
            },{
                    id: 1,
                    title: "الفصل الثاني",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                        },
                {
                    Id: 3,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "المحاضرة الرابعة"
                }]
                }, {
                    id: 2,
                    title: "الفصل الثالث",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    }]
                }, {
                    id: 0,
                    title: "الفصل الرابع",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    }]
                }, {
                    id: 1,
                    title: "الفصل الخامس",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    },
                    {
                        Id: 3,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الرابعة"
                    }]
                }, {
                    id: 2,
                    title: "الفصل السادس",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    }]
                }, {
                    id: 0,
                    title: "الفصل السابع",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    }]
                }, {
                    id: 1,
                    title: "الفصل الثامن",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    },
                    {
                        Id: 3,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الرابعة"
                    }]
                }, {
                    id: 2,
                    title: "الفصل التاسع",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    }]
                }, {
                    id: 0,
                    title: "الفصل العاشر",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    }]
                }, {
                    id: 1,
                    title: "الفصل الحادي عاشر",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    },
                    {
                        Id: 2,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الثالثة"
                    },
                    {
                        Id: 3,
                        url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                        title: "المحاضرة الرابعة"
                    }]
                }, {
                    id: 2,
                    title: "الفصل الثاني عشر",
                    lectures: [{
                        Id: 0,
                        url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                        title: "المحاضرة الأولى"

                    }, {
                        Id: 1,
                        url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                        title: "المحاضرة الثانية"
                    }]
                }]
        };
    },
    methods: {
        setselectedChapterIndex(index) {
            if (this.selectedChapterIndex !== index) {
                this.selectedChapterIndex = index;
            } else if (this.selectedChapterIndex === index) {
             
                this.selectedChapterIndex = null;
            }
           
        }, sethighlightedLectureIndex(index) {
            
            this.highlightedLectureIndex = index;
           

        },
        setSelectedLectureIndex(index) {
            this.selectedLectureIndex = index;
            this.savedSelectedChapterIndex = this.selectedChapterIndex;
        },
        displayLecture(index, lectureIndex) {
            this.$emit('lecture', this.chapters[index].lectures[lectureIndex]);
=======
            selectedIndex: null,
            lectures: [{
                id: 0,
                url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                title: "hello world"
            }, {
                id: 1,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
            }, {
                id: 2,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 3,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 4,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 5,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 6,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 7,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 8,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                },
                {
                    id: 9,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 10,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 11,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 12,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 13,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 14,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                }, {
                    id: 15,
                    url: "https://www.youtube.com/embed/BM2o8LG5QkE",
                    title: "hello world"
                }, {
                    id: 16,
                    url: "https://www.youtube.com/embed/Ulp1Kimblg0",
                    title: "Swift Programming Tutorial "
                }, {
                    id: 17,
                    url: "https://www.youtube.com/embed/5wZU8u4f0m8",
                    title: "How to show alert in Swift "
                },]
        }
    },
    methods: {
        setSelectedIndex(index) {
            this.selectedIndex = index;
        },
        displayLecture(index) {
            this.$emit('lecture', this.lectures[index]);
>>>>>>> 86d22e16ecdd7f058025f6d08c23e02cde4b0c73
        }
    }
}
