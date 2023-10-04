
fetch("/Student/getListData")
    .then(function (response) {
        return response.json()
    }).then(function (result) {
        return JSON.parse(result).Table
    }).then(function (final_result) {

        const t_body = document.getElementById('List_result')
        let tr_element = '';
        for (const i of final_result) {
            console.log(i)
            tr_element += 
            `<tr>
                <td>${i.id}</td>
                <td>${i.firstName}</td>
                <td>${i.lastName}</td>
                <td>${i.contact}</td>
                <td>${i.DOB}</td>
               <td><button>Edit</button></td>                
            </tr>`
        }
        
        t_body.insertAdjacentHTML('beforeend', tr_element)
    })
