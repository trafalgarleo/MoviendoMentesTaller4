const int trigPin = 11;
const int echoPin = 12;
volatile int contador = 0;
int velocimetro=3;


// defines variables
long duration;
int distance;


void setup() {
  pinMode(trigPin, OUTPUT); // Sets the trigPin as an Output
  pinMode(echoPin, INPUT); // Sets the echoPin as an Input
  pinMode(velocimetro, INPUT);
  Serial.begin(9600); // Starts the serial communication
  attachInterrupt(0,interrupcion,RISING);
}

void loop() {
  // Clears the trigPin
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);

  // Sets the trigPin on HIGH state for 10 micro seconds
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  // Reads the echoPin, returns the sound wave travel time in microseconds
  duration = pulseIn(echoPin, HIGH);

  // Calculating the distance
  distance= duration*0.034/2;

  // Prints the distance on the Serial Monitor
  //Serial.print("Revoluciones por segundo: ");
  Serial.print(contador);
  Serial.print(",");
  Serial.print(String(distance));
  Serial.println("");
  //Serial.println(" cm");
  contador=0;
  Serial.flush();
  delay(100);
}

void interrupcion() {
  contador++;
}