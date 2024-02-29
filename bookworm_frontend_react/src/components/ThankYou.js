import React, { useEffect, useState } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { saveAs } from 'file-saver';
import { Button } from 'react-bootstrap';
import config from '../config.json';

export default function ThankYou() {
    const location = useLocation();
    const invoiceData = location.state?.invoiceId;
    const products = location.state?.purchasedProducts;
    const totalAmount = location.state?.total;
    const navigate = useNavigate();
    console.log(config.port);

    // console.log(location);
    // console.log(products[0]);
    // console.log(location.state);
    // console.log(location.state.invoiceData);
    // console.log(invoiceData);

    useEffect(() => {
        if(invoiceData == null){
            navigate('/')
        }
    }, [invoiceData, navigate]);



    const handleDownloadInvoice = () => {
        axios.get(`http://localhost:${config.port}/api/invoice/pdf/${invoiceData}`, {
            responseType: 'blob',
        })
        .then((response) => {
            saveAs(new Blob([response.data]), `invoice_${invoiceData}.pdf`);
        })
        .catch((error) => {
            console.error("Download error: ", error);
        });
    };

    return (
        <div style={{height: '90vh'}}>
            <h1 style={{display: 'flex' ,justifyItems: 'center', justifyContent: 'center', marginTop: '20px'}}>Thank you for your purchase!</h1>
            <h2 style={{marginLeft: '20px', marginTop: '20px', marginBottom: '20px'}}>Items Purchased:</h2>
            <ul>
                {products?.map((product, index) => (
                    <li style={{display: 'flex', justifyContent: 'space-between'}} key={index}>
                        <b><p>{index+1} Book : {product.productEngName}</p></b>
                        <b><p style={{marginRight: '20px'}}>Price : {product.specialCost}</p></b>
                    </li>))}
            </ul>
            <h3 style={{display: 'flex', justifyItems: 'center', justifyContent: 'center'}}>Total Paid: {totalAmount}</h3>
            <div style={{display: 'flex', justifyContent: 'center', justifyItems: 'center', marginTop: '10vh'}}>
                <Button onClick={handleDownloadInvoice}>Download Invoice</Button>
                <Button onClick={() => navigate('/')} style={{marginLeft: '10px'}} >Go Home</Button>
            </div>
        </div>
    );
}