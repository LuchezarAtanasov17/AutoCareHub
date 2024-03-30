function onLikeButtonPress(commentId) {
    let token = document.querySelector("input[name='__RequestVerificationToken']").value;
    let likesCount = document.getElementById(`likes-${commentId}`);
    let likesIcon = document.getElementById(`like-icon-${commentId}`);

    let isCommentLiked = document.getElementById(`${commentId}-is-liked`);

    let data = new FormData();
    data.append('commentId', commentId);

    $.ajax({
        type: "POST",
        url: `/Comment/HandleLike`,
        data: data,
        headers: {
            "RequestVerificationToken": token
        },
        processData: false,
        contentType: false,
        success: async function (data) {
            if (isCommentLiked.value == 'false') {
                likesCount.textContent = parseInt(likesCount.textContent) + 1;
                likesIcon.classList.remove("notLikedPost");
                likesIcon.classList.add("likedPost");
                isCommentLiked.value = 'true';
            }
            else {
                likesCount.textContent = parseInt(likesCount.textContent) - 1;
                likesIcon.classList.remove("likedPost");
                likesIcon.classList.add("notLikedPost"); /*?????????????*/
                isCommentLiked.value = 'false';
            }
        },
        error: function (error) {
            console.error(error.statusCode);
            console.error('Error occurred while uploading object');
        }
    });
}