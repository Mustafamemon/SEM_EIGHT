# Load libraries
import pandas
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report
from sklearn.metrics import confusion_matrix
from sklearn.metrics import accuracy_score
from sklearn.neighbors import KNeighborsClassifier

help(KNeighborsClassifier.kneighbors)
# Load dataset
#url = "https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data"
names = ['sepal-length', 'sepal-width', 'petal-length', 'petal-width', 'class']
dataset = pandas.read_csv("iris/iris.data", names=names)



# shape
print(dataset.shape)

# class distribution
print(dataset.groupby('class').size())

# Split-out validation dataset
array = dataset.values
X = array[:,0:4]
Y = array[:,4]
t_size = 0.20
seed = 7
X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=t_size, random_state=seed)

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
        
