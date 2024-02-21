USE MilesCarRental;

INSERT INTO Location 
(Location, LocationDescription) VALUES
('Bogota', 'Capital City'),
('Medellin', 'Capital City'),
('Cartagena', 'Capital City');

INSERT INTO Vehicle 
(Vehicle, VehicleDescription, AmountAvaible, LocationId) VALUES
('Volvo', 'Truck', 5, 1),
('Ford', 'Family', 5, 1),
('Hyundai', 'Compact', 5, 1),
('BMW', 'Classic', 5, 2),
('KIA', 'Sport', 5, 2),
('Nissan', 'Future', 5, 2),
('Renault', 'Hybrid', 5, 3),
('Mazda', 'Large', 5, 3),
('Suzuki', 'Small', 5, 3);
