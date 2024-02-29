import React from 'react'

export default function ShowPDF({filename}) {
    const imageUrl = process.env.PUBLIC_URL + '/book_pdfs/'+filename+'.pdf'; 

  return (
    <img src={imageUrl} alt="My Image" />
    )
}
