(function () {
    var $result = $("#result");
    $("form").submit(function () {
        if (this.id == "addUserForm")
        {
            var inputUserId = "",
                inputUserName = $("#addUserForm .userName").val(),
                inputUserDateOfBirth = $("#addUserForm .userDateOfBirth").val(),
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "deleteUserForm")
        {
            var inputUserId = $("#deleteUserForm .userName").val(),
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "updateUserForm")
        {
            var inputUserId = $("#updateUserForm .userId").val(),
                inputUserName = $("#updateUserForm .userName").val(),
                inputUserDateOfBirth = $("#updateUserForm .userDateOfBirth").val(),
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "showUsersForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "addAwardForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = "",
                inputAwardTitle = $("#addAwardForm .awardTitle").val();
        }
        else if (this.id == "deleteAwardForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = $("#deleteAwardForm .awardId").val(),
                inputAwardTitle = "";
        }
        else if (this.id == "updateAwardForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = $("#updateAwardForm .awardId").val(),
                inputAwardTitle = $("#updateAwardForm .awardTitle").val();
        }
        else if (this.id == "showAwardsForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "getAwardByIdForm")
        {
            var inputUserId = "",
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = $("#getAwardByIdForm .awardId").val(),
                inputAwardTitle = "";
        }
        else if (this.id == "getAwardsIdByUsersIdForm")
        {
            var inputUserId = $("#getAwardsIdByUsersIdForm .userId").val(),
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = "",
                inputAwardTitle = "";
        }
        else if (this.id == "toAwardUserForm")
        {
            var inputUserId = $("#toAwardUserForm .userId").val(),
                inputUserName = "",
                inputUserDateOfBirth = "",
                inputAwardId = $("#toAwardUserForm .awardId").val(),
                inputAwardTitle = "";
        }
        $.ajax({
            method: "POST",
            url: "/UsersAndAwardsAjax",
            data: {
                userId: inputUserId,
                userName: inputUserName,
                userDateOfBirth: inputUserDateOfBirth,
                awardId: inputAwardId,
                awardTitle: inputAwardTitle,
                actionPlan: this.id,
            },
            success: function (response) {
                $result.html(response);
            },
        })
        return false;
    })
})();