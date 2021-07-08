# Load libraries
import pandas

from sklearn.metrics import classification_report
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score
from sklearn.neighbors import KNeighborsClassifier

#help(KNeighborsClassifier)

# Load dataset
#url = "https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data"
dataset = pandas.read_csv("Occupency_Detection/datatraining.txt", sep = ",", header = 0)

# shape
print(dataset.shape)

# head
print(dataset.head(3))

# class distribution
print(dataset.groupby('Occupancy').size())

dataset['Occupancy'] = dataset['Occupancy'].astype(str)

dataset_test = pandas.read_csv("Occupency_Detection/datatest.txt", sep = ",", header = 0)

# shape
print(dataset_test.shape)

# head
print(dataset_test.head(3))

# class distribution
print(dataset_test.groupby('Occupancy').size())

dataset_test['Occupancy'] = dataset_test['Occupancy'].astype(str)

# Split-out validation dataset
array = dataset.values
X_train = array[:,2:6]
Y_train = array[:,6]

array = dataset_test.values
X_test = array[:,2:6]
Y_test = array[:,6]

# Make predictions on validation dataset
knn = KNeighborsClassifier()
knn.fit(X_train, Y_train)
predictions = knn.predict(X_test)
print(accuracy_score(Y_test, predictions))
print(confusion_matrix(Y_test, predictions))
print(classification_report(Y_test, predictions))

for i in range(1, 10):
        knn = KNeighborsClassifier(i)
        knn.fit(X_train, Y_train)
        predictions = knn.predict(X_test)
        print("k=" + str(i) + ", Accuracy= " + str(accuracy_score(Y_test, predictions)))
        
