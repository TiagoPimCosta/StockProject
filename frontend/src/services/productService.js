const baseUrl = "https://localhost:5001";

//Add Product

export async function addProduct(name, colour, price, quantity, brand, description) {

  var data = {
              "name": name,
              "colour": colour,
              "price": price,
              "quantity": quantity,
              "brand": brand,
              "description": description
            };

  await fetch("https://localhost:5001/api/stock/addProduct", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  }).then((response) => {
    console.log(response);
  });
}

//Get Product
//Drop down list

//Get Product Details

export async function getProductDetails(name) {
  const response = await fetch(baseUrl+"/api/stock/" + name);
  if (response.ok) return response.json();
  throw response;
}

//Get All Products

export async function getProducts() {
  const response = await fetch(baseUrl+"/api/stock");
  if (response.ok) return response.json();
  throw response;
}

//StockIn

export async function stockIn({id, data}) {
  return fetch(baseUrl + "/api/stockIn" + id, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
}

//StockOut

export async function stockOut({id, data}) {
  return fetch(baseUrl + "/api/stockOut" + id, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
}