const baseUrl = "https://localhost:5001/api/stock";

// Add Product
// Done and Tested
export async function addProduct(name, colour, price, quantity, brand, description) {

  var data = {
              "name": name,
              "colour": colour,
              "price": price,
              "quantity": quantity,
              "brand": brand,
              "description": description
            };

  await fetch(baseUrl + "/addProduct", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  }).then((response) => {
    console.log(response);
  });
}
// Get Product Details
// Done and Tested
export async function getProductDetails(name) {
  const response = await fetch(baseUrl + "/" + name);
  if (response.ok) return response.json();
  throw response;
}

// Get All Products
// Done and Tested
export async function getProducts() {
  const response = await fetch(baseUrl);
  if (response.ok) return response.json();
  throw response;
}

// StockIn StockOut
// Done
export async function updateStock(name, quantity, stockIn) {

	var data = {
    "name": name,
    "quantity": parseInt(quantity),
    "StockIn": stockIn
  };
	

  await fetch(baseUrl + "/updateStock", {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  }).then((response) => {
    console.log(response);
  });
}