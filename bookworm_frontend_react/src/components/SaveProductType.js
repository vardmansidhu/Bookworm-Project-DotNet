import React, { useState } from "react";

const SaveProductType = () => {
  const [formData, setFormData] = useState({
    type_id: "",
    type_desc: "",
  });

  const handleChange = (event) => {
    const { name, value } = event.target;
    setFormData({
      ...formData,
      [name]: value,
    });
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    fetch(`http://localhost:${config.port}/api/productType/add`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(formData),
    })
      .then((response) => {
        response.json();
      })
      .then((data) => {
        console.log("Data submitted successfully:", data);
      });
  };

  return (
    <div>
      <h1>React Form Example</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Type ID:
          <input
            type="text"
            name="type_id"
            value={formData.type_id}
            onChange={handleChange}
          />
        </label>
        <br />
        <label>
          Type Description:
          <input
            type="text"
            name="type_desc"
            value={formData.type_desc}
            onChange={handleChange}
          />
        </label>
        <br />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default SaveProductType;
