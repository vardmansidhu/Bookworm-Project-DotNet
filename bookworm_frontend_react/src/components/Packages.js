import React, { useEffect, useState } from 'react'
import config from '../config.json';
import { useParams } from 'react-router-dom';

export default function Packages() {
    const [products, setProducts] = useState([]);
    const { libraryId } = useParams();

    useEffect(() => {
        const response = fetch(`http://localhost:${config.port}/api/Library/${libraryId}/products`);
        response.then(res => res.json()).then(data => setProducts(data));
    }, []);
    return (
        <>
            {products.map(product => (
                <div key={product.productId}>
                    <h1>{product.productEngName}</h1>

                </div>
            ))}
        </>
    )
}
