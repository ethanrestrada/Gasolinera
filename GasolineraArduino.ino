#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <ArduinoJson.h>
float flowRate = 1.0;
// Pines del LED y botón
unsigned long tiempoDetenido = 0;
int LED1 = 8;
int BOTON1 = 9;
int LED2 = 10;
int BOTON2 = 11;
int val = 0; // valor para almacenar el estado del botón
int state = 0; // 0 LED apagado, 1 encendido
int old_val = 0; // almacena el antiguo valor de val

// Variables para medir el tiempo
unsigned long startTime = 0; // tiempo de inicio cuando el LED se enciende
unsigned long elapsedTime = 0; // tiempo transcurrido

// Configuración de las pantallas LCD
LiquidCrystal_I2C lcd(0x26, 16, 2);
LiquidCrystal_I2C lcd2(0x27, 16, 2);

// Variables para datos del puerto serial
const int capacity = JSON_OBJECT_SIZE(2);
char jsonBuffer[128];

// Variable para indicar si se ha recibido un comando válido
bool comandoValido = false;

void setup() {
  lcd.init();
  lcd.backlight();
  lcd2.init();
  lcd2.backlight();
  lcd.setCursor(0, 0);
  lcd.print("BOMBA 1");
  lcd2.setCursor(0, 0);
  lcd2.print("BOMBA 2");
  Serial.begin(9600); // Inicializar comunicación serial
}
void llenarprepago(int BOMBA, int pantalla, int cantidad) {
  pinMode(BOMBA, OUTPUT);
  if (pantalla == 1) {
    lcd.setCursor(0, 1);
    lcd.print("BOMBA LISTA");
    delay(5000);
    lcd.clear();
  } else {
    lcd2.setCursor(0, 1);
    lcd2.print("BOMBA LISTA");
    delay(5000);
    lcd2.clear();
  }

  // Calcular el tiempo total para despachar la cantidad de litros indicada
  unsigned long totalDispenseTime = (unsigned long)((cantidad / flowRate) * 1000); // en milisegundos
  
  unsigned long startTime = millis();
  unsigned long currentTime = 0;

  while (currentTime < totalDispenseTime) {
    digitalWrite(BOMBA, HIGH);
    currentTime = millis() - startTime;
    unsigned long seconds = currentTime / 1000;
    unsigned long milliseconds = currentTime % 1000;
    
    if (pantalla == 1) {
      lcd.setCursor(0, 1);
      lcd.print(seconds);
      lcd.print(":");
      lcd.print(milliseconds);
      lcd.print(" LITROS");
    } else {
      lcd2.setCursor(0, 1);
      lcd2.print(seconds);
      lcd2.print(":");
      lcd2.print(milliseconds);
      lcd2.print(" LITROS");
    }
    delay(100);
  }
  
  digitalWrite(BOMBA, LOW);

  // Mostrar la cantidad total de litros despachados
  if (pantalla == 1) {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("BOMBA 1");
    lcd.setCursor(0, 1);
    lcd.print(cantidad);
    lcd.print(" LT TOTAL");
  } else {
    lcd2.clear();
    lcd2.setCursor(0, 0);
    lcd2.print("BOMBA 2");
    lcd2.setCursor(0, 1);
    lcd2.print(cantidad);
    lcd2.print(" LT TOTAL");
  }

  delay(5000);
  lcd.clear();
  lcd2.clear();
}
void llenartanque(int BOMBA, int BOTON, int pantalla) {
  bool bandera = true;
  bool bandera2 = false;
  unsigned long startTime = 0; // tiempo de inicio cuando el LED se enciende
  unsigned long elapsedTime = 0; // tiempo transcurrido
  unsigned long seconds = 0;
  unsigned long milliseconds = 0;
  
  pinMode(BOMBA, OUTPUT); // establecer el pin del LED como salida
  pinMode(BOTON, INPUT);

  while (bandera) {
    val = digitalRead(BOTON);

    if (state == 0 && bandera2 == true) {
      tiempoDetenido = elapsedTime;
      bandera = false;
      break;
    } // leer el estado del botón

    if (val == HIGH) {
      bandera2 = true;
    }

    if (val == HIGH && old_val == LOW) {
      state = 1 - state; // cambia el estado del LED
      if (state == 1) {
        startTime = millis();
        // guarda el tiempo de inicio cuando se enciende el LED
      }
      delay(10);
    }

    old_val = val; // almacenar el valor antiguo del botón

    if (state == 1) {
      digitalWrite(BOMBA, HIGH); // encender el LED
      elapsedTime = millis() - startTime; // calcular el tiempo transcurrido
    } else {
      digitalWrite(BOMBA, LOW); // apagar el LED
    }

    // Convertir el tiempo transcurrido en segundos y milisegundos
    seconds = elapsedTime / 1000;
    milliseconds = elapsedTime % 1000;

    // Mostrar el tiempo en la pantalla LCD
    if (pantalla == 1) {
      lcd.clear();
      lcd.setCursor(0, 0);
      lcd.print("BOMBA 1");
      lcd.setCursor(0, 1);
      lcd.print(seconds);
      lcd.print(":");
      lcd.print(milliseconds);
      lcd.print(" LITROS");
    } else if (pantalla == 2) {
      lcd2.clear();
      lcd2.setCursor(0, 0);
      lcd2.print("BOMBA 2");
      lcd2.setCursor(0, 1);
      lcd2.print(seconds);
      lcd2.print(":");
      lcd2.print(milliseconds);
      lcd2.print(" LITROS");
    }

    delay(100);
  }

  // Mostrar la cantidad de litros despachados
  if (pantalla == 1) {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("BOMBA 1");
    lcd.setCursor(0, 1);
    lcd.print(seconds);
    lcd.print(":");
    lcd.print(milliseconds);
    lcd.print(" LT TOTAL");
  } else if (pantalla == 2) {
    lcd2.clear();
    lcd2.setCursor(0, 0);
    lcd2.print("BOMBA 2");
    lcd2.setCursor(0, 1);
    lcd2.print(seconds);
    lcd2.print(":");
    lcd2.print(milliseconds);
    lcd2.print(" LT TOTAL");
  }
        
        Serial.print("{\"segundos\":");
        Serial.print(tiempoDetenido / 1000);
        Serial.print(",\"milisegundos\":");
        Serial.print(tiempoDetenido % 1000);
        
         
        Serial.println("}");

  delay(5000);
  lcd.clear();
  lcd2.clear();
}






void loop() {
  
  lcd.setCursor(0, 0);
  lcd.print("BOMBA 1");
  lcd2.setCursor(0, 0);
  lcd2.print("BOMBA 2");
  // Verificar si hay datos disponibles en el puerto serial
  if (Serial.available()) {
    // Leer los datos seriales entrantes
    Serial.readBytesUntil('\n', jsonBuffer, sizeof(jsonBuffer));
    
    // Parsear los datos JSON recibidos
    StaticJsonDocument<capacity> doc;
    DeserializationError error = deserializeJson(doc, jsonBuffer);

    // Si no hay error en la deserialización
    if (!error) {
      int bomba = doc["bomba"]; //pinbomba
      int tipoLlenado = doc["tipoLlenado"]; //Prepago o Tanque LLeno
      int cantlitros = doc["monto"]; //cantidad si es prepago
      
      // Si los datos coinciden con la condición requerida
      if (tipoLlenado == 1) {
        if (bomba == 7) {
          llenartanque(LED1, BOTON1,1);
        } else if (bomba == 8) {
          llenartanque(LED2, BOTON2,2);
        }
      }
      else if(tipoLlenado==0){
        if(bomba==7){
          llenarprepago(LED1,1,cantlitros);
        }
        if(bomba==8){
          llenarprepago(LED2,2,cantlitros);
        }
      }
    }
  }
}