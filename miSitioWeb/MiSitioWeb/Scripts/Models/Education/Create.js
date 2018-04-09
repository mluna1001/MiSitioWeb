const urlController = '/AdmEducations/Create';
const urlEducationLevel = '/AdmEducations/GetDataEducationLevel'

new Vue({
    el: "#MainDiv",
    created: function () {
        this.getEducationLevel();
    },
    computed: {
        vTargetType: function () {
            if (this.vModel.EducationLevelId != "") {
                for (var i = 0, l = this.vEducationLevel.length; i < l; i++) {
                    if (this.vEducationLevel[i].EducationLevelId == this.vModel.EducationLevelId) {
                        this.vModel.TargetType = this.vEducationLevel[i].TargetType;
                    }
                }
            }
        }
    },
    data: function () {
        return {
            vEducationLevel: [],
            vModel: { EducationId: "", EducationLevelId: "", StartDate: "", EndDate: "", School:"", State:"", Town:"", Country: "" },
        }
    },
    methods: {
        Defaults: function () {
        },
        getEducationLevel: function () {
            var self = this;
            axios.get(urlEducationLevel)
                .then(function (response) {
                    self.vEducationLevel = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                })
        },
        createEducation: function (e) {
            e.preventDefault();
            var self = this;
            var model = { form: self.vModel };
            $.when(saveObject(urlController, model.form)).then();
        }
    }
});

function saveObject(url, model) {
    $.ajax({
        type: 'Post',
        dataType: 'json',
        data: model,
        url: url,
        success: function (response) {
            toastr["success"]("Guardado correctamente", "Hecho");
            window.location.href = '/AdmEducations';
        },
        error: function (response) {
            window.location.href = '/AdmEducations';
        }
    });
}