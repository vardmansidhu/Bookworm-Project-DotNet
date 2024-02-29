import React, { useEffect, useState } from "react";
// import { set } from "react-hook-form";
import { useCookies } from "react-cookie";
import axios from "axios";
import { saveAs } from "file-saver";
import { Button } from "react-bootstrap";
import config from '../config.json';

function MyAccount() {
  const [user, setUser] = useState(null);
  const [orders, setOrders] = useState(null);
  const [products, setProducts] = useState(null);
  const [cookies, setCookie] = useCookies(["user"]);

  useEffect(() => {
    fetch(`http://localhost:${config.port}/api/customer/get/${cookies.user}`)
      .then((response) => response.json())
      .then((data) => {
        setUser(data);
        console.log(data);
      });
  }, []);

  useEffect(() => {
    fetch(`http://localhost:${config.port}/api/invoice/orders/${cookies.user}`)
      .then((response) => response.json())
      .then((data) => {
        const transformedData = data.map((order) => ({
          invoiceId: order[0],
          customerId: order[1],
          invoiceAmount: order[2],
          invoiceDate: order[3].split("T")[0],
          basePrice: order[4],
          sellingPrice: order[5],
          productId: order[6],
          transactionTypeId: order[7] === 1 ? "Purchase" : "Rent",
        }));

        const groupedByInvoice = transformedData.reduce((acc, order) => {
          if (!acc[order.invoiceId]) {
            acc[order.invoiceId] = [];
          }
          acc[order.invoiceId].push(order);
          return acc;
        }, {});

        setOrders(groupedByInvoice);
        console.log(groupedByInvoice);
      });
  }, []);

  useEffect(() => {
    fetch(`http://localhost:${config.port}/api/product/names`)
      .then((response) => response.json())
      .then((data) => {
        const transformedData = data.map((product) => ({
          productId: product[0],
          productEngName: product[1],
        }));
        setProducts(transformedData);
        console.log(transformedData);
      });
  }, []);

  return (
    <div
      style={{
        fontFamily: "Montserrat, sans-serif",
        padding: "20px",
        backgroundColor: "#f5f5f5",
      }}
    >
      {user && (
        <div
          style={{
            padding: "30px",
            backgroundColor: "#fff",
            borderRadius: "10px",
            boxShadow: "0px 0px 10px rgba(0,0,0,0.1)",
          }}
        >
          <h1 style={{ textAlign: "center", color: "#333" }}>Profile</h1>
          <div
            style={{
              display: "flex",
              justifyContent: "space-between",
              padding: "30px",
            }}
          >
            <div style={{ width: "45%" }}>
              <h2 style={{ color: "#666" }}>Name: {user.customerName}</h2>
              <h2 style={{ color: "#666" }}>Email: {user.customerEmail}</h2>
            </div>
            <div style={{ width: "45%" }}>
              <h2 style={{ color: "#666" }}>Contact No. : {user.contactNo}</h2>
              <h2 style={{ color: "#666" }}>Date of Birth: {user.dob.split("T")[0]}</h2>
            </div>
          </div>
        </div>
      )}
      <div style={{ marginTop: "20px" }}>
        <h1 style={{ padding: "30px", textAlign: "center", color: "#333" }}>
          Your Order History
        </h1>
        {orders &&
          Object.entries(orders).map(([invoiceId, orders], index) => (
            <div
              key={index}
              style={{
                borderRadius: "10px",
                boxShadow: "0px 0px 10px rgba(0,0,0,0.1)",
                marginBottom: "20px",
                backgroundColor: "#fff",
              }}
            >
              <div
                style={{
                  display: "flex",
                  justifyContent: "space-between",
                  width: "80%",
                  margin: "auto",
                  padding: "20px",
                }}
              >
                <h3>Order ID: {index + 1}</h3>
                <h3>Total Amount: {orders[0].invoiceAmount}</h3>
                <h3>
                  Download Invoice:{" "}
                  <Button
                    onClick={(e) => {
                      e.preventDefault();
                      axios
                        .get(
                          `http://localhost:${config.port}/api/invoice/pdf/${invoiceId}`,
                          {
                            responseType: "blob",
                          }
                        )
                        .then((response) => {
                          saveAs(
                            new Blob([response.data]),
                            `invoice_${invoiceId}.pdf`
                          );
                        })
                        .catch((error) => {
                          console.error("Download error: ", error);
                        });
                    }}
                  >
                    Download
                  </Button>
                </h3>
              </div>
              {orders.map((order, index) => {
                console.log(products);
                const product = products?.find(
                  (product) => product.productId === order.productId
                );
                return (
                  <div
                    key={index}
                    style={{
                      display: "flex",
                      justifyContent: "space-between",
                      padding: "10px",
                      width: "80%",
                      margin: "0 auto",
                      backgroundColor: "#fff",
                      // borderRadius: "10px",
                      // boxShadow: "0px 0px 10px rgba(0,0,0,0.1)",
                    }}
                  >
                    <p style={{ color: "#666" }}>
                      Product:{" "}
                      {product ? product.productEngName : "Product not found"}
                    </p>
                    <p style={{ color: "#666" }}>MRP: {order.basePrice}</p>
                    <p style={{ color: "#666" }}>
                      Selling Price: {order.sellingPrice}
                    </p>
                    <p style={{ color: "#666" }}>
                      Purchased On: {order.invoiceDate}
                    </p>
                    <p style={{ color: "#666" }}>
                      Transaction Type: {order.transactionTypeId}
                    </p>
                  </div>
                );
              })}
            </div>
          ))}
      </div>
    </div>
  );
}

export default MyAccount;
