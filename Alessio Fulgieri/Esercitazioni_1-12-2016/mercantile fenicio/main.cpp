#include <vector>
#include <string>
#include <algorithm>
#include <iostream>
#include <stdlib.h>
#include <time.h>

using namespace std;

void putBaseGoods(vector<string> &);
bool swapFor(vector<string> &,string ,string );
bool compareString(string ,string );
void sellAll(vector<string> &);
template<typename T> void printVector(const vector<T> &);
void pauseAndClear();

int main()
{
    vector<string> hold;
    vector<string>::iterator i;
    srand(time(NULL));

    putBaseGoods(hold);
    printVector(hold);
    pauseAndClear();

    hold.pop_back();
    printVector(hold);
    pauseAndClear();

    hold.push_back("te");
    printVector(hold);
    pauseAndClear();

    swapFor(hold,"lana","frumento");
    printVector(hold);
    pauseAndClear();

    i=find(hold.begin(),hold.end(),"vino");
    if(i!=hold.end())
    {
        hold.erase(i);
    }
    printVector(hold);
    pauseAndClear();

    sort(hold.begin(),hold.end(),compareString);
    printVector(hold);
    pauseAndClear();

    random_shuffle(hold.begin(),hold.end());
    printVector(hold);
    pauseAndClear();

    sellAll(hold);
    printVector(hold);
    pauseAndClear();



    return 0;
}

void pauseAndClear()
{
    system("pause");
    system("cls");
}

template<typename T> void printVector(const vector<T> &vect)
{
    for(unsigned int i=0;i<vect.size();i++)
    {
        cout<<vect[i]<<endl;
    }
}
void sellAll(vector<string> &hold)
{
    hold.clear();
    hold.push_back("oro");
}

bool compareString(string first,string second)
{
    return (first.compare(second)<0);
}

bool swapFor(vector<string> &hold,string toGive,string toRecive)
{
    vector<string>::iterator i;

    i=find(hold.begin(),hold.end(),toGive);

    if(i==hold.end())
    {
        return false;
    }
    else
    {
        *i=toRecive;
        return true;
    }

}

void putBaseGoods(vector<string> &hold)
{
    hold.push_back("vino");
    hold.push_back("lana");
    hold.push_back("avorio");
    hold.push_back("legno");
}
