Original task specification is attached.

Database connection is not implemented in this solution. The test data is defined in runtime and it has its own methods.

There were some not accurate part of the definition.
1. Special price: it is not clear based on the definition if the unit price 50 the special price is 3 for 130. that means the only discounted qty is 3,6,9 etc and any additional qty is on normal price, or 3 for 130 means any qty greater or equal 3 achieves the discount and changes the unit price to 130/3 and calculates with this new price
2. This line from the specification also invalid "two Bs and price them at 45 (for a total price so far of 95)." SKU B's normal unit price is 30 and discounted price 45 for 2 items. 95 is not valid in any way of calculation.

I worked in the SAP world in the last 19 years and special prices are always defined as a new discounted unit price, that is why I went with that solution also it would be possible to create additional volume discount, like 
  SKU: A
  Qty    SpecialPrice
  3      130
  6      240

This would need also a slightly different logic.


