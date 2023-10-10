
const FirstName = document.getElementById('txt_firstName');
const LastName = document.getElementById('txt_LastName');
const Contact = document.getElementById('txt_Contact');
const dateOfBirth = document.getElementById('txt_DOB');

const Save_button = document.getElementById('btn_save')

Save_button.addEventListener("click", saveHandlear)

function saveHandlear() {

    const Post_data = {
        firstName: FirstName.value,
        LastName: LastName.value,
        Contact: Contact.value,
        DOB: dateOfBirth.value
    }


    fetch('/Student/SAVE_DATA', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
        body: JSON.stringify(Post_data)
    })


}


const btn_get_data = document.getElementById('btn_get_data')

btn_get_data.addEventListener("click", getDataHandlear)

function getDataHandlear() {
    const id = document.getElementById('get_id').value;
    const params = {
        student_id: parseInt(id)
    }
 

    fetch("/Student/get_data", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
        },
        body: JSON.stringify(params)
    }).then((resp) => resp.json())
        .then((resp1) => JSON.parse(resp1))
        .then((final_result) => {
            FirstName.value = final_result.Table[0].firstName
            LastName.value = final_result.Table[0].lastName
            Contact.value = final_result.Table[0].contact
            dateOfBirth.value = final_result.Table[0].DOB
        })

}


