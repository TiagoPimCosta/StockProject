const baseUrl = "http://localhost:5001";

//Add Product

export async function addProduct({id, data}) {
  return fetch(baseUrl+"/api/stock", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
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